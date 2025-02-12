﻿/*
 * Copyright (c) 2023 Proton AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProtonVPN.BugReporting.Attachments.Sources;
using ProtonVPN.Common.Configuration;
using ProtonVPN.Common.Logging;

namespace ProtonVPN.App.Tests.BugReporting.Attachments.Source
{
    [TestClass]
    public class DiagnosticsLogFileSourceTest : LogFileSourceBaseTest<DiagnosticsLogFileSource>
    {
        protected override DiagnosticsLogFileSource Construct(string folderPath, int maxNumOfFiles)
        {
            ILogger logger = Substitute.For<ILogger>();
            IConfiguration configuration = Substitute.For<IConfiguration>();
            configuration.ReportBugMaxFileSize.Returns(MAX_FILE_SIZE);
            configuration.DiagnosticsLogFolder.Returns(folderPath);
            configuration.MaxDiagnosticLogsAttached.Returns(maxNumOfFiles);

            return new DiagnosticsLogFileSource(logger, configuration);
        }
    }
}