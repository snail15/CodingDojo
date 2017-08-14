# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from django.db.models import Q
from django.core.urlresolvers import reverse
from .models import *
from django.contrib import messages
import bcrypt
from datetime import datetime
from time import strftime, strptime, gmtime

# Create your views here.
def index(request):
    users = User.objects.all()
    i = 1
    for user in users:
        user.registered = user.created_at.strftime("%a, %d %b %Y %H:%M")
        user.row = i
        i += 1
    context = {
        'users': users
    }
    return render(request, 'ajax_pagination/index.html', context)

def search_name(request):
    
    if 'from_date' in request.POST:
        from_date = get_date(request.POST['from_date'])
        print("from", from_date)
        filtered_user = User.objects.filter(created_at__range=(from_date, datetime.now()))
        filtered_user = assign_row(filtered_user)
        context = {
            'users': filtered_user
        }
        return render(request, 'ajax_pagination/table.html', context)

    else:
        filtered_user = User.objects.filter(Q(first_name__startswith=request.POST['search_name']) | Q(last_name__startswith=request.POST['search_name']))
        filtered_user = assign_row(filtered_user)
        context = {
            'users': filtered_user
        }
        return render(request, 'ajax_pagination/table.html', context)

def assign_row(data):
    i = 1
    for user in data:
        user.registered = user.created_at.strftime("%a, %d %b %Y %H:%M")
        user.row = i
        i += 1
    return data

def get_date(data):
    date = datetime.strptime(data, "%Y-%m-%d")
    return date