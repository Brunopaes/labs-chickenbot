# -*- coding: utf-8 -*-
from unittest import mock
from src import bot

import unittest


def mock_bot(message):
    print('Hello World')


class TestBot(unittest.TestCase):
    def setUp(self):
        self.bot = bot

    @mock.patch('bot.reply_to', side_effect=mock_bot)
    def test_send_welcome(self, magic):
        self.bot.send_welcome('')
