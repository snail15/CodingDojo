# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse

# Create your views here.

def index(request):
    request = "index"
    return HttpResponse(request)

def register(request):
    request = "register"
    return HttpResponse(request)

def create_session(request):
    request = "create session"
    return HttpResponse(request)