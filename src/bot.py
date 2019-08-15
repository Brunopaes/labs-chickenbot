# -*- coding: utf-8 -*-
import telebot
import json
import os


path = \
    os.path.abspath('{}/data/credentials.json'.
                    format(os.getcwd() + os.sep + os.pardir))

API_TOKEN = json.loads(open(path, 'r').read())['API_TOKEN']

bot = telebot.TeleBot(API_TOKEN)


@bot.message_handler(commands=['start'])
def send_welcome(message):
    """This function gets the incoming message and replies it with an
    'Hello World'.

    Parameters
    ----------
    message : telebot.types.Message
        The message object.

    """
    bot.reply_to(message, "Hello World!")


@bot.message_handler(func=lambda message: True)
def echo_message(message):
    """This function gets the incoming message and replies with it.

    Parameters
    ----------
    message : telebot.types.Message
        The message object.

    """
    bot.reply_to(message, 'Vai se fuder')


bot.polling()
