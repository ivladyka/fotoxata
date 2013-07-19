<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryEdit.ascx.cs" Inherits="GalleryEdit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script language="javascript">
    function VIKKI_CheckUploadedFiles() {
        var ul = $find("<%= auFile.ClientID %>");
        var inputs = ul.getInvalidFiles();
        for (i = inputs.length - 1; i >= 0; i--) {
            if (!ul.isExtensionValid(inputs[i])) {
                alert('Тільки файли з розширенням jpg можуть бути завантажені на сервер. Будь ласка видаліть файли з іншими розширеннями.');
                return false;
            }
        }
        if (ul.get_element().innerHTML.indexOf('ruUploadFailure') != -1) {
            alert('Максимальний розмір файла 100Мб. Допустимий формат зображень jpg. Будь ласка видаліть файли помічені знаком оклику.');
            return false;
        }
        if (ul._uploadsInProgress > 0) {
            alert('Будь ласка дочекайтесь завантаження всіх файлів.');
            return false;
        }
        return true;
    }
</script>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2"  align="center" border="0" >	
    <tr>			
		<td align="right">Завантажити фотографії:
		</td>
		<td >
                <telerik:RadAsyncUpload runat="server" ID="auFile" 
                    AllowedFileExtensions="jpg" MultipleFileSelection="Automatic">
                    <Localization Remove="Видалити" Select="Вибрати" />
                </telerik:RadAsyncUpload>
        </td>
    </tr>
	<tr>
	    <td colspan='2' align="right">
	   <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
        </td>
	</tr>
</table>