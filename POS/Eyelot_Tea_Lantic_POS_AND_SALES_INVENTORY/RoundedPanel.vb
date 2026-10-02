Imports System.Drawing.Drawing2D

Public Class RoundedPanel
    Inherits Panel

    Public Property CornerRadius As Integer = 20

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim radius As Integer = CornerRadius
        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        Using path As New GraphicsPath()
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
            path.CloseFigure()

            Me.Region = New Region(path)

            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using
        End Using
    End Sub
End Class