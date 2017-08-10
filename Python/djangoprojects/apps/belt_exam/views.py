# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from django.core.urlresolvers import reverse
from .models import *
from django.contrib import messages
import bcrypt

# Create your views here.

def index(request):
    return render(request, "belt_exam/index.html")

def validate(request):
    if request.POST['type'] == 'registration':
        errors = User.objects.validator(request.POST)
        if len(errors) >= 1:
            for tag, error in errors.iteritems():
                messages.error(request, error, extra_tags=tag)
            return redirect(reverse("belt:index"))
        else:
            server_password = bcrypt.hashpw(request.POST["password"].encode(), bcrypt.gensalt())
            user_name = request.POST["name"]
            new_user = User.objects.create(name=user_name, username=request.POST['user_name'], password=server_password)
            new_user.save()
            request.session["user_name"] = user_name
            request.session["user_id"] = new_user.id
            return redirect(reverse("belt:show"))
    else:
        if len(User.objects.filter(username=request.POST["user_name"])) < 1:
            tag = "no_user"
            error = "Invalid Username"
            messages.error(request, error, extra_tags=tag)
            return redirect(reverse("belt:index"))
        else:
            visiting_user = User.objects.get(username=request.POST["user_name"])
            input_pw = request.POST["password"]
            if not bcrypt.checkpw(input_pw.encode('utf8'), visiting_user.password.encode('utf8')):
                tag = "password_incorrect"
                error = "Invalid Password"
                messages.error(request, error, extra_tags=tag)
                return redirect(reverse("belt:index"))
            else:
                request.session["user_name"] = visiting_user.name
                request.session["user_id"] = visiting_user.id
                return redirect(reverse("belt:show"))

def show(request):
    trips = Trip.objects.all()
    context = {
        "trips": trips
    }

    return render(request, "belt_exam/show.html", context)

def destroy(request):
    del request.session["user_name"]
    del request.session["user_id"]
    return redirect(reverse("belt:index"))

def add(request):
    return render(request, "belt_exam/add.html")

def create(request):
    current_user = User.objects.get(id=request.session["user_id"])
    errors = Trip.objects.validator(request.POST)
    if len(errors) >= 1:
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect(reverse("belt:add"))
    new_trip = Trip.objects.create(destination=request.POST['destination'], start=request.POST['start'], end=request.POST['end'], plan=request.POST['plan'], created_by=request.session["user_id"])
    new_trip.users.add(current_user)
    new_trip.save()
    return redirect(reverse("belt:show"))
    
def detail(request, id):
    detail_trip = Trip.objects.get(id=id)
    created_user = User.objects.get(id=detail_trip.created_by)
    context = {
        "trip": detail_trip,
        "created_user": created_user
    }
    return render(request, "belt_exam/detail.html", context)

def join(request, id):
    joined_trip = Trip.objects.get(id=id)
    joining_user = User.objects.get(id=request.session["user_id"])
    joined_trip.users.add(joining_user)
    joined_trip.save()
    return redirect(reverse("belt:show"))