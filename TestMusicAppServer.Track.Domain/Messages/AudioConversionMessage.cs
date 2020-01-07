﻿using System;

namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioConversionMessage
    {
        public string FileName { get; set; }

        public AudioConversionAdditionalData AdditionalData { get; set; }
    }
}
