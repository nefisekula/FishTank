# Introduction 
FishTank is Class Library project that allows to be created 3 kinds of fish which are Gold, Angel and Babel; get the some information about the fish tank and save current task information to an XML file.

#Tank
Tank service is the main service of the project. It has 3 methods:
AddFish, GetFishList and Feed. 
Feed method gives the information the weight in grams of the total required fish food.

#Fish
Fish is an abstact class with 2 abstract properties: FishType and RequiredFood. Name is a regular properties.

#XmlSaver
XmlSaver is a service that saves the current tank information to the XML file. It gets the file name from appsettings file's FileName key.
Path for the file is project's application directory.


#Project Structure
FishTank.Core: It is a class library and core of the project. Tank, Fish and XmlSaver services are under this project.
FishTank.Tests: It is a test project. NUnit was used for the tests.
FishTank.UI: It is a console application was added to see the result. Also service registerations and configurations are being handled in this project.

# Build and Test
Project has a appsettings.fle with keys belows. 

##appsettings.json files
```json
{
  FileName": "Tank.xml"
}
```

Environment
https://alm.deltatre.it/tfs/International%20Market/Golf.TV%202.0/_build?definitionId=796

Repository
https://github.com/nefisekula/FishTank