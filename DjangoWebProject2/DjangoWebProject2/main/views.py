from django.views import View
from django.shortcuts import render
from .models import Message

class IndexView(View):
    def get(self, request):
        messages = Message.objects.all()
        return render(request, 'main/index.html', {'messages': messages})

