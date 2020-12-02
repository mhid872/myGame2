Public Class form1
    Private Sub form1keydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.J
                picturebox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
                Me.Refresh()
            Case Keys.Up
                MoveTo(picturebox1, 0, -5)
            Case Keys.Down
                MoveTo(picturebox1, 0, 5)
            Case Keys.Left
                MoveTo(picturebox1, -5, 0)
            Case Keys.Right
                MoveTo(picturebox1, 5, 0)

            Case Else

        End Select
    End Sub
    Dim r As New Random()
    Sub Randommove(p As PictureBox)
        Dim xdir As Integer = r.Next(-20, 21)
        Dim ydir As Integer = r.Next(-20, 21)

        MoveTo(p, xdir, ydir)
    End Sub

    Sub move(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(picturebox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(ctureBox)
        Dim x, y As Integer
        Dim p As Object = Nothing

        If p.Location.X > picturebox1.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < picturebox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub
    Sub Move(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x, p.Location.Y + y)
    End Sub
    Private Sub form1_keydown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles picturebox1.Click

    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(picturebox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > picturebox1.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < picturebox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub



    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "picturebox1" And Collision(p, "WIN", other) Then
            Dim g As New Form2
            Me.Visible = False
            g.ShowDialog()
            other.visible = False
            Return
            Me.BackColor = Color.Green
            other.visible = False
            Return
        End If
        If p.Name = "picturebox4" And Collision(p, "picturebox1") Then
            Dim g As New Form3
            Me.Visible = False
            g.ShowDialog()
            other.visible = False
            Return
            Me.BackColor = Color.Green
            other.visible = False
            Return
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        chase(picturebox4)
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub










End Class

