## labs-chickenbot

Optimized for python 3.6 - [Language changes subjected](README.md#notes)

This project aims in creating a chatbot for '[Museu da Pessoa](http://www.museudapessoa.net)'. 
The idea is use Telegram/WhatsApp/Facebook APIs to get all incoming messages, process it with
NLP and intent recognition techniques (in market - IBM Watson or in house made API) and replies it
as a person from the Museum's collection.
  
------------------

### Credits and Support

- [Bruno Paes](https://github.com/Brunopaes)
- [Fernando Sinigaglia](https://github.com/FernandoSini)
- [Guilherme Heitzmann](https://github.com/PhoenixBRnnf)
- [Leonado Briotto](https://github.com/briottoleo)
- Leonardo Messias

#### Advisors and Supporters
- [André Insardi](https://github.com/andreinsardi)
- [Carlos Rafael](https://github.com/carlosrafaelgn)
- Flávio Marques

-----------------------

### Dependencies

For developers, python requirements could be find in the project's root. For installing the requirements, 
in your ___venv___ or ___anaconda env___, just run the following command:

`pip install -r requirements.txt`

----------------

### Project's Structure

```bash 
.
└── labs-chickenbot
    ├── data
    │   └── credentials.json
    ├── docs
    │   ├── reference_articles
    │   ├── ...
    │   └── credits.txt
    ├── src
    │   ├── __init__.py
    │   └── bot.py
    ├── tests
    │   └── unittests
    │       ├── data
    │       └── __init__.py
    ├── .gitignore
    ├── LICENSE
    ├── README.md
    └── requirements.txt
```

#### Directory description

- __data:__ The data dir. Group of non-script support files.
- __docs:__ The documentation dir.
- __src:__ The scripts & source code dir.
- __tests:__ The unittests dir.

-----------------------

### References

- __Telegram's API:__ [link](https://github.com/eternnoir/pyTelegramBotAPI)
- __Telegram's Documentation:__ [link](https://core.telegram.org)
- __WhatsApp's API:__ [link](https://www.whatsapp.com/business/api)

--------------

### Usage Notes

#### Running

For running it, on the ``~/src`` directory just run the follow command:

`python bot.py` 

#### Notes

- Instead of python, Node JS may be used.
- Chickenbot is just a provisional name

---------------

### Versioning

This project is under development.

#### Roadmap

__It needed to:__

- Create the bot end - responsible for getting and replying messages.
    - Getting messages - almost done  
    - Replying messages - almost done  

- Create the NLP end:
    - Use _in house_ api?
        - Techniques:
            - Word Embeddings
            - Word2Vec
            - Word Histogram - word bag
    - Use _in market_ api?
        - IBM Watson API

--------------
