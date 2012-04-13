Imports System.Net
Imports System.Xml
Imports System.Xml.Linq
Imports System.IO
Imports Bti.Babble.Model
Imports System.Text

Module Module1

    Sub Main()
        'SendXmlString(xml.ToString())
        'SendXmlString(xml2.ToString())

        Dim evt As New CommentEvent() With {
                .Id = 0,
                .Image = "http://prod.bti.tv/media/users/matthew_doig.jpg",
                .Message = "This is a test of a babble post",
                .PubDate = DateTime.Now,
                .Time = New TimeSpan(1, 0, 0),
                .Type = "comment",
                .User = "Matthew Doig"
            }

        Dim settings As New XmlWriterSettings()
        settings.OmitXmlDeclaration = True

        Dim sb As New StringBuilder()
        Using writer = XmlWriter.Create(sb, settings)
            writer.WriteStartElement("babble")
            evt.WriteXml(writer)
            writer.WriteEndElement()
        End Using

        SendXmlWebClient(sb.ToString())
    End Sub

    Sub SendXmlString(xmlstring As String)
        Dim req As HttpWebRequest = Nothing
        Dim resp As HttpWebResponse = Nothing
        Try
            'Dim url = "http://localhost:49722/Service.svc/xml/babble"
            Dim url = "http://prod.bti.tv/Service.svc/xml/babble"
            req = WebRequest.Create(url)
            req.Method = "POST"
            req.ContentType = "application/xml; charset=utf-8"
            req.Timeout = 30000
            req.Headers.Add("SOAPAction", url)

            Dim xmlDoc = New System.Xml.XmlDocument()
            xmlDoc.XmlResolver = Nothing
            xmlDoc.LoadXml(xmlstring)
            Dim sXML = xmlDoc.InnerXml
            req.ContentLength = sXML.Length
            Dim sw As New System.IO.StreamWriter(req.GetRequestStream())
            sw.Write(sXML)
            sw.Close()
            resp = req.GetResponse()
            Dim respStream = resp.GetResponseStream()
            If respStream IsNot Nothing Then
                Dim responseBody = New StreamReader(respStream).ReadToEnd()
                Console.WriteLine(responseBody)
            Else
                Console.WriteLine("HttpWebResponse.GetResponseStream returned null")
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub SendXmlWebClient(xmlstring As String)
        Dim client As New WebClient
        'Dim url = "http://localhost:49722/Service.svc/xml/babble"
        Dim url = "http://prod.bti.tv/babble/Service.svc/xml/babble"
        'Dim data As String = ""
        client.Headers.Add("Content-Type", "application/xml")
        Dim response As String = client.UploadString(url, "POST", xmlstring)
    End Sub

    Dim xml = <?xml version="1.0" encoding="utf-16"?>
              <babble>
                  <event>
                      <header>
                          <time>00:00:07</time>
                          <type>comment</type>
                          <user>Christine Diez</user>
                          <message>80 degrees in march. Not looking forward to July! #TOOHOT</message>
                          <image>http://prod.bti.tv/media/users/christine_diez.jpg</image>
                      </header>
                      <body/>
                  </event>
              </babble>
    Dim xml2 = <?xml version="1.0" encoding="utf-16"?>
               <babble>
                   <event>
                       <header>
                           <id>0</id>
                           <pubDate>4/12/2012 4:27:17 PM</pubDate>
                           <time>00:00:07</time>
                           <type>comment</type>
                           <user>Christine Diez</user>
                           <message>80 degrees in march. Not looking forward to July! #TOOHOT</message>
                           <image>http://prod.bti.tv/media/users/christine_diez.jpg</image>
                       </header>
                       <body/>
                   </event>
               </babble>
End Module
