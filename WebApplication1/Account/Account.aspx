<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="WebApplication1.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
        <style type="text/css">
        input {
        vertical-align:middle;
	height:16px;
	line-height:16px;
	margin:0;
	border:1px #ccc solid;
	padding: 10px 0 10px 5px;
	width:250px;
	margin-right:8px;
	float:left;
        }
        .regnow {
	width:300px;
	margin-left:150px;
	height:40px;
	background:#db2f2f;
	border:none;
	color: #FFF;
	font-size: 15px;
	font-weight: 700;
    cursor:pointer;
}
            table tr td{
                line-height:40px;
           
                padding-bottom:20px
            }
    </style>
    <script src="../js/jquery.validate.min.js"></script> 
    <script>
        $.validator.addMethod("existUser", function (value,element,params) {

            var flag=true;
		$.ajax({
			error:function(){alert("你好")},
			async:false,
			type:"POST",
			url:"/ashx/existUser.ashx",
			data:"username="+value,
			dataType:"text",
			success:function(data){
                if (data == "no") {

                    flag = false;

                }
				
			}
		})
		
		return flag;

        })

         $.validator.addMethod("equalCode", function (value,element,params) {

            var flag=true;
		$.ajax({
			error:function(){alert("你好")},
			async:false,
			type:"POST",
			url:"/ashx/ValidateCodeEqual.ashx",
			data:"validate="+value,
			dataType:"text",
			success:function(data){
                if (data == "no") {

                    flag = false;

                }
				
			}
		})
		
		return flag;

        })
        $(function () {

            $("#form1").validate({

                rules: {
                    "txtName": {
                        required: true,
                        existUser:true

                    },
                    "txtRealName": {
                        required:true
                    },
                    "txtConfirmPwd": {
                        required: true,
                        equalTo:$("input[name=txtPwd]")
                    },
                    "txtPwd": {
                        required: true,
                       

                    },
                    "txtCode": {
                        required: true,
                        equalCode:true

                    }


                },

                messages: {
                   "txtName": {
                       required: "用户名不能为空",
                        existUser:"用户名已存在"

                    },
                    "txtRealName": {
                        required:"真名不能为空"
                    },
                    "txtConfirmPwd": {
                        required: "密码不能为空",
                        equalTo:"确认密码与密码不一致"
                    },
                    "txtPwd": {
                        required: "密码不能为空",
                        

                    },
                    "txtCode": {
                        required: "验证码不能为空",
                        equalCode:"验证码输入有误"

                    }


                }


            })

            $("#imgCode").click(function () {


                $(this).attr("src", "/ashx/ValidateCode.ashx?id=" + new Date().getSeconds() + new Date().getMilliseconds())

            })

        })

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size:small">
  <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td style="width: 10px"><img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
    <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
    <td width="10"><img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
  </tr>
</table>


<table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
    <td><div align="center">
      <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
        <tr>
          <td height="33" colspan="6"><p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p></td>
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
          <td valign="top" width="37%" align="left" style="height: 26px">
            <input type="text" name="txtName" id="txtUserName" placeholder="请输入用户名" />
              <input type="hidden" name="returnurl" value="<%=url %>" />
              
              <span style="font-size:14px;color:red" id="userNameMsg"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtRealName" /></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">密码：</td>
          <td valign="top" width="37%" align="left">
              <input type="password" name="txtPwd" placeholder="请输入密码" /></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">确认密码：</td>
          <td valign="top" width="37%" align="left">
              <input type="password" name="txtConfirmPwd" /></td>          
        </tr>
         <tr>
          <td width="24%" height="26" align="center" valign="top">Email：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtMail" id="txtUserMail" /><span style="font-size:14px;color:red" id="userMailMsg"></span></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">地址：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtAddress" /></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">手机：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtPhone" /></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">
              验证码：</td>
          <td valign="top" width="37%" align="left">
              <input type="text" name="txtCode" id="txtValidateCode" /><a href="javascript:void(0)" id="valiateCode"><img src="/ashx/ValidateCode.ashx?id=1" id="imgCode"/></a><span style="font-size:14px;color:red" id="userCodeMsg"></span></td>          
        </tr>
        <tr>
          <td colspan="2" align="center"><input type="submit" id="btnReg" value="同意协议并注册" class="regnow" /></td>           
        </tr>
        <tr>
          <td colspan="2" align="center">&nbsp;</td>           
        </tr>
      </table>
      <div class="STYLE5">---------------------------------------------------------</div>
    </div>	
    </td>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
  </tr>
</table>

<table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="3" bgcolor="#DDDDCC"><img src="../Images/touming.gif" width="27" height="9" /></td>
  </tr>
</table>
</div>
</asp:Content>
