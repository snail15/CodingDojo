# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse
from time import gmtime, strftime

# Create your views here.

def index(request):

    context = {
        "time": strftime("%m-%d-%Y %H:%M %p", gmtime())
    }

    return render(request, "timedisplay/index.html", context)
