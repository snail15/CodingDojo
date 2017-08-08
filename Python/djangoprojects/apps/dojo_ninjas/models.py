# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class Dojo(models.Model):
    name = models.CharField(max_length=100)
    city = models.CharField(max_length=30)
    state = models.CharField(max_length=2)
    desc = models.TextField()
    def __repr__(self):
        return "<Dojo object: Name:{0}, City:{1}>".format(self.name, self.city)

class Ninja(models.Model):
    first_name = models.CharField(max_length=30)
    last_name = models.CharField(max_length=30)
    dojo = models.ForeignKey(Dojo, related_name="ninjas")
    def __repr__(self):
        return"<Ninja object: Name:{0}, Dojo:{1}>".format(self.first_name, self.dojo)
