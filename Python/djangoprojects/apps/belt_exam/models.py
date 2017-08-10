# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class UserManager(models.Manager):
    def validator(self, postData):
        errors = {}
        if len(postData["password"]) < 8:
            errors["password"] = "Password must be at least 8 characters!"
        if len(postData["name"]) < 3:
            errors['name_error'] = "Your name must be at least 3"
        if len(postData["user_name"]) < 3:
            errors['username_error'] = "Your username must be at least 3"
        if postData["confirm_pass"] != postData["password"]:
            errors['confrim'] = "Your password does not match with confirm field"
        return errors

class User(models.Model):
    name = models.CharField(max_length=55)
    username = models.CharField(max_length=55)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()

class TripManager(models.Manager):
    def validator(self, postData):
        errors = {}
        if len(postData["destination"]) < 1:
            errors["destination_error"] = "Destination is empty!!"
        if len(postData["start"]) < 1:
            errors["start_error"] = "Start date is empty!!"
        if len(postData["end"]) < 1:
            errors["end_error"] = "End date is empty!!"
        if len(postData["plan"]) < 1:
            errors["plan_error"] = "Got No Plan??!!"
        if postData["start"] == postData["end"]:
            errors["date"] = "Can't have same start and end date!"
        return errors
class Trip(models.Model):
    destination = models.CharField(max_length=255)
    start = models.CharField(max_length=255)
    end = models.CharField(max_length=255)
    plan = models.TextField()
    users = models.ManyToManyField(User, related_name = "trips")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    created_by = models.IntegerField(null=True)
    objects = TripManager()
