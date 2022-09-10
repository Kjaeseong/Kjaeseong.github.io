---
title: "소식"
layout: archive
permalink: categories/News
author_profile: true
sidebar_main: true
---


{% assign posts = site.categories.News %}
{% for post in posts %} {% include archive-single.html type=page.entries_layout %} {% endfor %}