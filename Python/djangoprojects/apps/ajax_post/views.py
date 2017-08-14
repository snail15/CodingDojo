# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from django.core.urlresolvers import reverse
from .models import *

# Create your views here.

def index(request):
    posts = Post.objects.all().order_by('id')
    return render(request, "ajax_post/index.html", {"posts": posts})

def create(request):
    new_post = Post.objects.create(content=request.POST['post_content'])
    return render(request, "ajax_post/post.html", {"post_content": new_post.content})
