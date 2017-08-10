from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name="index"),
    url(r'^validate$', views.validate, name="validate"),
    url(r'^show$', views.show, name="show"),
    url(r'^logout$', views.destroy, name="destroy"),
    url(r'^add$', views.add, name="add"),
    url(r'^create$', views.create, name="create"),
    url(r'^detail/(?P<id>\d+)$', views.detail, name="detail"),
    url(r'^join/(?P<id>\d+)$', views.join, name="join"),
]