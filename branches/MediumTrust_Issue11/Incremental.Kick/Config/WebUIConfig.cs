using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace Incremental.Kick.Config {
    [XmlRoot("webUIConfig")]
    public class WebUIConfig {
        [XmlIgnore]
        public static string SectionName { get { return "webUI"; } }

        [XmlAttribute("categoryCacheDurationInSeconds")]
        public int CategoryCacheDurationInSeconds;

        [XmlAttribute("categoryStoryListCacheDurationInSeconds")]
        public int CategoryStoryListCacheDurationInSeconds;

        [XmlAttribute("categoryStoryCountCacheDurationInSeconds")]
        public int CategoryStoryCountCacheDurationInSeconds;

        [XmlAttribute("storyCacheDurationInSeconds")]
        public int StoryCacheDurationInSeconds;

        [XmlAttribute("userProfileCacheDurationInSeconds")]
        public int UserProfileCacheDurationInSeconds;
    }

    public class WebUIConfigReader : ConfigReaderBase {
        public static WebUIConfig GetConfig()
        {
            return ConfigReaderBase.Read(WebUIConfig.SectionName) as WebUIConfig;
        }
    }

    [ComVisible(false)]
    public class WebUISectionHandler : IConfigurationSectionHandler {
        private XmlSerializer xs = new XmlSerializer(typeof(WebUIConfig));

        public object Create(object parent, object hmm, XmlNode configSection) {
            return xs.Deserialize(new StringReader(configSection.OuterXml)) as WebUIConfig;
        }
    }
}