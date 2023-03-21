// (c) Apr 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>


function AddReferencesForEtherYatriMobileAgent(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("EtherYatri");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}


function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
	try
	{
        oldSuppressUIValue = dte.SuppressUI;
		var strProjectPath = wizard.FindSymbol("PROJECT_PATH");
		var strProjectName = wizard.FindSymbol("PROJECT_NAME");
		var strSafeProjectName = CreateSafeName(strProjectName);
		wizard.AddSymbol("SAFE_PROJECT_NAME", strSafeProjectName);

		var bEmptyProject = 0; //wizard.FindSymbol("EMPTY_PROJECT");

		var proj = CreateCSharpProject(strProjectName, strProjectPath, "defaultDll.csproj");

		var InfFile = CreateInfFile();
		if (!bEmptyProject)
		{
			AddReferencesForEtherYatriMobileAgent(proj);
			AddFilesToCSharpProject(proj, strProjectName, strProjectPath, InfFile, false);
		}
		proj.Save();
	}
	catch(e)
	{
		if( e.description.length > 0 )
			SetErrorInfo(e);
		return e.number;
	}
    finally
    {
   		dte.SuppressUI = oldSuppressUIValue;
   		if( InfFile )
			InfFile.Delete();
    }
}

function GetCSharpTargetName(strName, strProjectName)
{
	var strTarget = strName;

	switch (strName)
	{
		case "readme.txt":
			strTarget = "ReadMe.txt";
			break;
		case "File1.cs":
			strTarget = "Agent1.cs";
			break;
		case "assemblyinfo.cs":
			strTarget = "AssemblyInfo.cs";
			break;
	}
	return strTarget; 
}

function DoOpenFile(strName)
{
	var bOpen = false;
    
	switch (strName)
	{
		case "Agent1.cs":
			bOpen = true;
			break;
	}    
	return bOpen; 
}

function SetFileProperties(oFileItem, strFileName)
{
    if(strFileName == "File1.cs" || strFileName == "assemblyinfo.cs" )
    {
        oFileItem.Properties("SubType").Value = "Code";
    }
}

