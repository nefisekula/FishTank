using FishTank.Core;
using FishTank.Core.Interfaces;
using FishTank.Core.Repositories;
using FishTank.Tests.Helper;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace FishTank.Tests
{
    public class XmlSaverTests
    {
        protected IConfiguration Config;
        private ITank _tank;
        private ITankSaver _sut;
        private FileHelper _fileHelper;

        [SetUp]
        public void Setup()
        {
            _fileHelper = new FileHelper();
            Config = new ConfigurationBuilder()
                        .AddInMemoryCollection(new List<KeyValuePair<string, string>>() {
                            new KeyValuePair<string, string>("FileName","TestTank.xml"),
                        })
                        .Build();

            _tank = new Tank();

            _sut = new XmlSaver(Config, _tank);
        }

        [Test]
        public void Should_Return_Error_Msg_For_Fault_File_Name()
        {
            var faultConfig = new ConfigurationBuilder()
                        .AddInMemoryCollection(new List<KeyValuePair<string, string>>() {
                            new KeyValuePair<string, string>("FaultFileName","TestTank.xml"),
                        })
                        .Build();

            var sut = new XmlSaver(faultConfig, _tank);

            var actual = sut.Save();

            Assert.AreEqual("File path is not found!", actual);
        }

        [Test]
        public void Should_Return_Error_Msg_For_Null_GetFishList_Tank()
        {
            var sut = new XmlSaver(Config, null);

            var actual = sut.Save();

            Assert.AreEqual("XML file could not be created!", actual);
        }

        [Test]
        public void Should_Save_Xml_File_For_The_Tank()
        {
            var actual = _sut.Save();
            var path = _fileHelper.ToApplicationPath("TestTank.xml");

            Assert.AreEqual($"TestTank.xml file created in the {path} folder.", actual);
        }
    }
}
