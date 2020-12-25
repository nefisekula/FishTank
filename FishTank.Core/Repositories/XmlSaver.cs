using FishTank.Core.Abstract;
using FishTank.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace FishTank.Core.Repositories
{
    public class XmlSaver : ITankSaver
    {
        private readonly ITank _tank;
        private string _fileName;

        public XmlSaver(IConfiguration config, ITank tank)
        {
            _tank = tank;
            _fileName = config.GetValue<string>("FileName");
        }

        public string Save()
        {
            if (string.IsNullOrEmpty(_fileName))
                return "File path is not found!";

            var xmlDoc = GenerateFishTankXml();

            if (xmlDoc == null)
                return "XML file could not be created!";

            var path = ToApplicationPath();

            if (string.IsNullOrEmpty(path))
                return "File path is not correct!";

            xmlDoc.Save(path);

            return $"{_fileName} file created in the {path} folder.";
        }

        private XDocument GenerateFishTankXml()
        {
            if (_tank == null || _tank.GetFishList() == null)
            {
                return null;
            }

            XDocument fishTankXDoc = new XDocument(
                new XElement("FishTank",
                    new XElement("RequiredFoodInGram", _tank.Feed()),
                    new XElement("Fishes")
                )
            );

            var fishesXml = fishTankXDoc.Descendants("Fishes").FirstOrDefault();
            if (fishesXml != null && _tank.GetFishList() != null)
            {
                foreach (var fish in _tank.GetFishList())
                {
                    fishesXml.Add(new XElement(nameof(Fish),
                        new XAttribute(nameof(fish.FishType), fish.FishType.ToString()),
                        new XElement(nameof(fish.Name), fish.Name),
                        new XElement(nameof(fish.FoodRequired), fish.FoodRequired)
                        )
                    );
                }
            }
            fishTankXDoc.Declaration = new XDeclaration("1.0", "utf-8", "true");
            return fishTankXDoc;
        }

        private string ToApplicationPath()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                                .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return Path.Combine(appRoot, _fileName);
        }
    }
}
