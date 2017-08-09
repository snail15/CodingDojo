# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class Book(models.Model):
    name = models.CharField(max_length=255, blank=True, null=True)
    desc = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    def __repr__(self):
        return "Book: id#{0}, Name: {1}, Desc: {2}".format(self.id, self.name, self.desc)

class Author(models.Model):
    first_name = models.CharField(max_length=255, blank=True, null=True)
    last_name = models.CharField(max_length=255, blank=True, null=True)
    email = models.CharField(max_length=255, blank=True, null=True)
    books = models.ManyToManyField(Book, related_name = "authors")
    create_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    notes = models.TextField(null=True, blank=True)
    def __repr__(self):
        return "Author: id#{0}, Name: {1}, Email: {2}".format(self.id, self.first_name, self.email)
