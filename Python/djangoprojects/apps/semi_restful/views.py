# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, reverse, redirect

# Create your views here.

def index(request):
    return render(request, "semi_restful/index.html")


