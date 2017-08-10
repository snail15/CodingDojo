# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render,redirect
from django.core.urlresolvers import reverse
from .models import *

# Create your views here.

def index(request):
    users = User.objects.all()
    context = {
        "users": users
    }
    return render(request, "semi_restful/index.html", context)

def new(request):
    return render(request, "semi_restful/new.html")

def create(request):
    new_user = User.objects.create(name=request.POST['name'], email=request.POST['email'])
    new_user.save()
    return redirect(reverse("restful:index"))

def show(request, id):
    displayed_user = User.objects.get(id=id)
    context = {
        "user": displayed_user
    }
    return render(request, "semi_restful/show.html", context)

def edit(request, id):
    edited_user = User.objects.get(id=id)
    if request.method == "GET":
        context = {
            "user": edited_user
        }
        return render(request, "semi_restful/edit.html", context)
    elif request.method == "POST":
        new_name = request.POST["name"]
        new_email = request.POST['email']
        edited_user.name = new_name
        edited_user.email = new_email
        edited_user.save()
        return redirect(reverse("restful:index"))