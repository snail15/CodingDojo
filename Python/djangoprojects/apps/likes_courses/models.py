# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class User(models.Model):
    name = models.CharField(max_length=255, blank=True, null=True)
    email = models.CharField(max_length=255, blank=True, null=True)
    def __repr__(self):
        return "User: Name: {0}".format(self.name)

class Book(models.Model):
    name = models.CharField(max_length=255, blank=True, null=True)
    uploader = models.ForeignKey(User, related_name='uploaded_books')
    liked_users = models.ManyToManyField(User, related_name='liked_books')
    def __repr__(self):
        return "Book: Name: {0}".format(self.name)
