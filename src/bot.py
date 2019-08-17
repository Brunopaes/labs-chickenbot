# -*- coding: utf-8 -*-
import telebot
import json
import os


path = \
    os.path.abspath('{}/data/settings.json'.
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
    bot.send_message(message.chat.id, message.text)


@bot.message_handler(commands=['help'])
def send_audio(message):
    """This function gets the incoming message and sends an vitas audio.

    Parameters
    ----------
    message : telebot.types.Message
        The message object.

    """
    audio = \
        open('/Users/brunopaes/Desktop/labs-chickenbot/data/vitsa.mp3', 'rb')

    bot.send_audio(message.chat.id, audio)


@bot.message_handler(commands=['image'])
def send_image(message):
    """This function gets the incoming message and sends an image.

    Parameters
    ----------
    message : telebot.types.Message
        The message object.

    """
    img = \
        open('/Users/brunopaes/Desktop/labs-chickenbot/data/4377539_0.jpg', 'rb')

    bot.send_photo(message.chat.id, img)


bot.polling()
