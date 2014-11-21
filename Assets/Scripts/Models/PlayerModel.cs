using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("players")]
public class PlayerContainer
{
    [XmlElement("player")]
    public List<PlayerDataModel> playerList = new List<PlayerDataModel>();


    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static PlayerContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(PlayerContainer));
        return serializer.Deserialize(new StringReader(text)) as PlayerContainer;
    }
}
public class PlayerDataModel {

    [XmlAttribute("first_name")]
    public string FirstName { get; set; }

    [XmlAttribute("last_name")]
    public string LastName { get; set; }

    [XmlAttribute("username")]
    public string Username { get; set; }

    [XmlAttribute("best_score")]
    public int BestScore { get; set; }

    [XmlAttribute("rank")]
    public int Rank { get; set; }

}
