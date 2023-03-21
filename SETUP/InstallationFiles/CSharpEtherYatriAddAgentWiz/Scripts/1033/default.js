// Original was (c) 2001 Microsoft Corporation
// Modified on June 06, 2003 by Siddharth Uppal <siddharthuppal@yahoo.co.in>
function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
	try
	{
		var strTarget = wizard.FindSymbol("ITEM_NAME");
		var strClassName = strTarget.split(".");
		var bValid = wizard.ValidateCLRIdentifier(strClassName[0]);
		if (!bValid)
			return VS_E_WIZARDBACKBUTTONPRESS;
		
        oldSuppressUIValue = dte.SuppressUI;
		var strProjectName 	= wizard.FindSymbol("PROJECT_NAME");
		var strSafeProjectName 	= CreateSafeName(strProjectName);
		wizard.AddSymbol("SAFE_PROJECT_NAME", strSafeProjectName);
		SetTargetFullPath(selObj);
		var strProjectPath	= wizard.FindSymbol("TARGET_FULLPATH");
		var strTemplatePath 	= wizard.FindSymbol("TEMPLATES_PATH");

		var strTpl = "";
		var strName = "";
		var InfFile = CreateInfFile();

		AddReferencesForClass(selProj);
		AddFilesToCSharpProject(selObj, strProjectName, strProjectPath, InfFile, true);
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

function SetFileProperties(oFileItem, strFileName)
{
}


