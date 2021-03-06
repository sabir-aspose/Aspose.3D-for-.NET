﻿Imports System.IO
Imports Aspose.ThreeD
Imports Aspose.ThreeD.Entities
Imports Aspose.ThreeD.Utilities
Imports Aspose.ThreeD.Shading

Namespace Geometry_Hierarchy
    Public Class MeshGeometryData
        Public Shared Sub Run()

            ' ExStart:ShareMeshGeometryData  
            ' Initialize scene object
            Dim scene As New Scene()

            ' Define color vectors
            Dim colors As Vector3() = New Vector3() {
                New Vector3(1, 0, 0),
                New Vector3(0, 1, 0),
                New Vector3(0, 0, 1)}
            ' Call Common class create mesh using polygon builder method to set mesh instance 
            Dim mesh As Mesh = Common.CreateMeshUsingPolygonBuilder()

            Dim idx As Integer = 0
            For Each color As Vector3 In colors
                ' Initialize cube node object
                Dim cube As New Node("cube")
                cube.Entity = mesh
                Dim mat As New LambertMaterial()
                ' Set color
                mat.DiffuseColor = color
                ' Set material
                cube.Material = mat
                ' Set translation
                cube.Transform.Translation = New Vector3(System.Math.Max(System.Threading.Interlocked.Increment(idx), idx - 1) * 20, 0, 0)
                ' Add cube node
                scene.RootNode.ChildNodes.Add(cube)
            Next

            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir()
            MyDir = MyDir & RunExamples.GetOutputFilePath("MeshGeometryData.fbx")
            
            ' Save 3D scene in the supported file formats
            scene.Save(MyDir, FileFormat.FBX7400ASCII)
            ' ExEnd:ShareMeshGeometryData 

            Console.WriteLine(Convert.ToString(vbLf & "Mesh’s geometry data shared successfully between multiple nodes." & vbLf & "File saved at ") & MyDir)

        End Sub
    End Class
End Namespace
