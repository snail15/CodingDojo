# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from time import gmtime, strftime
from django.utils.crypto import get_random_string

# Create your views here.

def index(request):

    
    current_time = strftime("%A %B, %d, %Y, %I:%M %p", gmtime())
    context = {
        "time": current_time
    }

    return render(request, "randomwords/index.html", context)

def generate(request):
    
    if request.method == "POST":

        try:
            request.session['attempt'] += 1
        except:
            request.session['attempt'] = 1
        
        random_word = get_random_string(length=14)
        request.session['random_word'] = random_word

    return redirect('/randomwords')

