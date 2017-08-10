# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class User(models.Model):
    name = models.CharField(max_length=50)
    email = models.CharField(max_length=70)
    created_at = models.DateTimeField(auto_now_add=True)
    def __repr__(self):
        return "User: id#: {0}, name: {1}. email: {2}".format(self.id, self.name, self.email)
