Partial Class user_verifyotp
    Inherits System.Web.UI.Page

    Protected Sub btnVerifyOtp_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim emailOtpEntered As String = txtEmailOtp.Text


        Dim emailOtpStored As String = Session("emailOtp")

        If emailOtpEntered = emailOtpStored Then
            ' OTPs verified, insert user data into database
            Dim userInfo = CType(Session("userInfo"), Object)
            Dim obj As New class1
            Dim query As String = String.Format("INSERT INTO usertable (username, password, email, gender, address, mobileno) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", userInfo.Name, userInfo.Password, userInfo.Email, userInfo.Gender, userInfo.Address, userInfo.Phone)
            obj.exequery(query)

            lblMessage.Text = "Verification successful! Registration complete."
            lblMessage.Visible = True
        Else
            lblMessage.Text = "OTP verification failed. Please try again."
            lblMessage.Visible = True
        End If
    End Sub
End Class
