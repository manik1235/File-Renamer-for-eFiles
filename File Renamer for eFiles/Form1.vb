Public Class Form1


    Structure FileListStructure
        ' TODO: methods to clear the list
        ' TODO: methods to add to the list
        ' TODO: methods to remove an item from the list. (Interface?)
        ' DONE: Implement the IList(Of...) interface

        ' Holds the information about the files being modified.

        Implements IList(Of String) ' It's a list, so use the standard list interface (Of String)


        Structure PathAndFileNameStructure
            ' These are lists because there can be many files being changed at once.
            Dim FullPathAndFileName As List(Of String)  ' Holds the entire path and file name of the added file
            Dim PathOnly As List(Of String)             ' Holds the path portion only
            Dim OriginalFileNameOnly As List(Of String) ' Holds the file name portion only, including extension
            Dim ModifiedFileNameOnly As List(Of String) ' Holds the modified file name only, including extension
            Dim Extension As List(Of String)
        End Structure

        Dim ItemData As PathAndFileNameStructure         ' Array of the structures that hold the files.




        Default Public Property Item(index As Integer) As String Implements IList(Of String).Item
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public ReadOnly Property Count As Integer Implements ICollection(Of String).Count
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of String).IsReadOnly
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public Sub Insert(index As Integer, item As String) Implements IList(Of String).Insert
            Throw New NotImplementedException()
        End Sub

        Public Sub RemoveAt(index As Integer) Implements IList(Of String).RemoveAt
            Throw New NotImplementedException()
        End Sub

        Public Sub Add(item As String) Implements ICollection(Of String).Add
            ' Called When an item is added to the List
            ' When added, parse the file name into: Path, OriginalName, Extension, ModifiedName

            Debug.Print(item)
            Debug.Print(FileIO.FileSystem.GetName(item))
            Debug.Print(FileIO.FileSystem.GetParentPath(item))


            Try
                ' Currently throwing Null Object exception, I need to figure out how to initialize stuff.

                ItemData.FullPathAndFileName.Add(item) ' Add the full path and filename to the ItemData
                ItemData.OriginalFileNameOnly.Add(FileIO.FileSystem.GetName(item)) ' Add only the file name
                ItemData.PathOnly.Add(FileIO.FileSystem.GetParentPath(item))
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
            'Throw New NotImplementedException()
        End Sub

        Public Sub Clear() Implements ICollection(Of String).Clear
            Throw New NotImplementedException()
        End Sub

        Public Sub CopyTo(array() As String, arrayIndex As Integer) Implements ICollection(Of String).CopyTo
            Throw New NotImplementedException()
        End Sub

        Public Function IndexOf(item As String) As Integer Implements IList(Of String).IndexOf
            Throw New NotImplementedException()
        End Function

        Public Function Contains(item As String) As Boolean Implements ICollection(Of String).Contains
            Throw New NotImplementedException()
        End Function

        Public Function Remove(item As String) As Boolean Implements ICollection(Of String).Remove
            Throw New NotImplementedException()
        End Function

        Public Function GetEnumerator() As IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
            Throw New NotImplementedException()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Throw New NotImplementedException()
        End Function
    End Structure

    Dim FileList As FileListStructure ' Variable to hold the file list data

    Private Sub OriginalItemsCheckedListBox_DragDrop(sender As Object, e As DragEventArgs) Handles OriginalItemsCheckedListBox.DragDrop
        ' Code snippet is from:
        ' https://msdn.microsoft.com/en-us/library/system.windows.forms.control.allowdrop(v=vs.110).aspx 
        ' Handle FileDrop data.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' Assign the file names to a string array, in 
            ' case the user has selected multiple files.
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Try
                ' Add the files to the FileList structure.
                Debug.Print(files(0))
                Debug.Print(files.Count)

                Dim file As String ' Holds the individual string in the array to cycle thru.

                For Each file In files
                    FileList.Add(file)
                Next
                'Me.picture = Image.FromFile(files(0))
                ' Set the picture location equal to the drop point.
                'Me.pictureLocation = Me.PointToClient(New Point(e.X, e.Y))
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        End If

    End Sub

    Private Sub OriginalItemsCheckedListBox_DragEnter(sender As Object, e As DragEventArgs) Handles OriginalItemsCheckedListBox.DragEnter
        ' If the data is a file or a bitmap, display the copy cursor.
        ' Code snippet is from:
        ' https://msdn.microsoft.com/en-us/library/system.windows.forms.control.allowdrop(v=vs.110).aspx 
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
End Class

