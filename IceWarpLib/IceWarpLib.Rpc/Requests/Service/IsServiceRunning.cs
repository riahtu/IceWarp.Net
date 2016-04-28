﻿using System.Xml;
using IceWarpLib.Objects.Helpers;
using IceWarpLib.Objects.Rpc.Enums;
using IceWarpLib.Rpc.Responses;
using IceWarpLib.Rpc.Utilities;

namespace IceWarpLib.Rpc.Requests.Service
{
    /// <summary>
    /// Check if specified IceWarp service is running or not.
    /// <para><see href="https://www.icewarp.co.uk/api/#IsServiceRunning">https://www.icewarp.co.uk/api/#IsServiceRunning</see></para>
    /// </summary>
    public class IsServiceRunning : IceWarpCommand<IsServiceRunningResponse>
    {
        /// <summary>
        /// Service type specification
        /// </summary>
        public TServiceType Service { get; set; }

        /// <inheritdoc />
        protected override void BuildCommandParams(XmlDocument doc, XmlElement command)
        {
            var commandParams = GetCommandParamsElement(doc);

            XmlHelper.AppendTextElement(commandParams, ClassHelper.GetMemberName(() => Service), Service);

            command.AppendChild(commandParams);
        }

        /// <inheritdoc />
        /// <returns>See <see cref="IsServiceRunningResponse"/></returns>
        public override IsServiceRunningResponse FromHttpRequestResult(HttpRequestResult httpRequestResult)
        {
            return new IsServiceRunningResponse(httpRequestResult);
        }
    }
}
