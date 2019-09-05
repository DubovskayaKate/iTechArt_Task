
## Abstract Factory

*Short Description*

You must solve the task using one of the design patterns.

**Requirements**

Customer company produces cars. The vehicle equipment consists of different types of engines, different wheel diameters and different suspensions. There are three types of configuration: economy, standard and extra.  
Implement a class that returns the desired set of parts, depending on the type of configuration.

## Adapter

*Short Description*

You must solve the task using one of the design patterns.

**Requirements**

You have class, which return list of books in XML format. And you have another class, which accept list of books in json format and return oldest book from the list. Implement class, which will help to use xml list of book as a provider of data for second class.

```
class Library
    method getBooksXML()

class BooksAnalyzer
    method getOldestBook(json booksList)
```

## Facade

*Short Description*

You must solve the task using one of the design patterns.


**Requirements**

You have next classes:

```
class VideoFile
    consturctor(string filename)

class MPEG4Codec implements Codec
    consturctor()

class OGGCodec implements Codec
    consturctor()

class VideoCoverter
    consturctor()
    method convert(VideoFile file, Codec codec)
```

Implement class that will provide simple interface with one method

```
class SimpleConverter
    methdod convert(string filename, string format)
```

## Proxy

*Short Description*

You must solve the task using one of the design patterns.

**Requirements**

You have a class that receives yesterday's exchange rate from an external resource.

```
interface IYesterdayRate
    method getRate()

class YesterdayRate implements IYesterdayRate
    method getRate()
```

Implement a class with the same interface that will cache the results of queries to an external resource?