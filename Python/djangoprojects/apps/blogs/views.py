# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect

# Create your views here.

def index(request):
    response = "Placeholder to later display.."
    return HttpResponse(response)

def show(request):
    request = "Show func"
    return HttpResponse(request)

def create(request):
    request = "create"
    return HttpResponse(request)

def edit(request):
    request = "edit"
    return HttpResponse(request)
def destroy(request):
    return redirect("/blogs")

def new(request):
    request = "Placeholder ot later display to create new..."
    return HttpResponse(request)

