from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^register$', views.register),
    url(r'^login$', views.create_session),
    url(r'^new$', views.register),
    url(r'^$', views.index)

]