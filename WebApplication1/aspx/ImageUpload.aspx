<%@ Page Title="" Language="C#" MasterPageFile="~/Master/UserMaster.Master" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="WebApplication1.aspx.ImageUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SWFUpload Application Demo (ASP.Net 2.0)</title>
	<link href="/Css/default.css" rel="stylesheet" type="text/css" />
     <link href="/Css/imgareaselect-default.css" rel="stylesheet" />
 
    <script src="../js/jquery.imgareaselect.js"></script>
	<script type="text/javascript" src="/js/swfupload.js"></script>
	<script type="text/javascript" src="/js/handlers.js"></script>
	<script type="text/javascript">
        var swfu;
        function getImageUrl(file, serverdata) {
              $("#selectbanner").attr("src",serverdata);
           $("#selectbanner").show();

            // the event when the user has chosen the image
              function preview(img, selection) {

            $('#selectbanner').data('x', selection.x1);

            $('#selectbanner').data('y', selection.y1);

            $('#selectbanner').data('w', selection.width);

                  $('#selectbanner').data('h', selection.height);

               
                  //为按钮绑定事件，点击就会把裁剪图片的信息传给后端++++++++
                  $("#btnPhotoCut").click(function () {
                      var params = {

                          x: selection.x1,
                          y: selection.y1,
                          w: selection.width,
                          h: selection.height,
                          url:$("#imagePath").val(),
                          action:"cut"
                      }
                         //post the image data user  has chosen
                      $.post("/ashx/upload.ashx", params, function (data) {
                          if (data != "no") {

                              $("#imgSrc").attr("src", data);

                          }

                      }, "text")



                  })

        }


            if (serverdata != "no") {

                $("#selectbanner").attr("src", serverdata);
                $("#imagePath").val(serverdata);
                   $('#selectbanner').imgAreaSelect({
                    selectionColor: 'blue', x1: 0, y1: 0, x2: 150,y2: 100,

                    //maxWidth: 950, minWidth: 950,  minHeight: 400, maxHeight: 400,

                    selectionOpacity: 0.1, onSelectEnd: preview
                });

            }


        }
        window.onload = function () {
            $("#selectbanner").hide();
			swfu = new SWFUpload({
				// Backend Settings
				upload_url: "/ashx/upload.ashx",
                post_params : {
                    "ASPSESSID" : "<%=Session.SessionID %>"
                },

				// File Upload Settings
				file_size_limit : "2 MB",
				file_types : "*.jpg",
				file_types_description : "JPG Images",
				file_upload_limit : 0,    // Zero means unlimited

				// Event Handler Settings - these functions as defined in Handlers.js
				//  The handlers are not part of SWFUpload but are part of my website and control how
				//  my website reacts to the SWFUpload events.
				swfupload_preload_handler : preLoad,
				swfupload_load_failed_handler : loadFailed,
				file_queue_error_handler : fileQueueError,
				file_dialog_complete_handler : fileDialogComplete,
				upload_progress_handler : uploadProgress,
				upload_error_handler : uploadError,
				upload_success_handler :getImageUrl,
				upload_complete_handler : uploadComplete,

				// Button settings
				button_image_url : "images/XPButtonNoText_160x22.png",
				button_placeholder_id : "spanButtonPlaceholder",
				button_width: 160,
				button_height: 22,
				button_text : '<span class="button">Select Images <span class="buttonSmall">(2 MB Max)</span></span>',
				button_text_style : '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
				button_text_top_padding: 1,
				button_text_left_padding: 5,

				// Flash Settings
				flash_url : "/js/swfupload.swf",	// Relative to this file
				flash9_url : "/js/swfupload/swfupload_FP9.swf",	// Relative to this file

				custom_settings : {
					upload_target : "divFileProgressContainer"
				},

				// Debug Settings
				debug: false
			});
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
   

    

   
		

	<div id="content" style="margin:0 auto;width:80%">
			    
		
	    <div id="swfu_container" >
		    <div>
				<span id="spanButtonPlaceholder"></span>
		    </div>
		    <div id="divFileProgressContainer" style="height: 75px;"></div>
		    <div id="thumbnails"></div>
	    </div>
		</div>
   <div style="margin:0 auto;width:80%">


     <img id="selectbanner" width="500px" height="300px"/>
            <input type="button" value="头像截取" id="btnPhotoCut" />
            <input type="hidden" id="imagePath" />
            <br />
            <img id="imgSrc" />



      
       </div>

</asp:Content>
