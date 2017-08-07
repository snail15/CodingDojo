# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse

# Create your views here.

def index(request):
    request = "survey index method"
    return HttpResponse(request)

def new(request):
    request = "Create new survey"
    return HttpResponse(request)