   M S B A M L   `   `   `  ����M  ICourseWork Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CourseWork_ProjectCourseWork_Project  5   	   7 clr-namespace:CourseWork_ProjectCourseWork_Project  5   	   #    CourseWork_Project.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CourseWork_Project     5   	   4control clr-namespace:CourseWork_Project     5   	     � Title$  Function Graph��5	   	   $	��543��6    $��1104.5��6-   .��5
      � -   5        $��MainGrid��5
       � ColumnDefinitions 5   
   �� 5      $	��17* �6   �� 5      $��57 �6   �� 5      $��69 �6   �� 5      $	��921 �6   �� 5      $��2* �6   �� 5      $	��30* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��22 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��241 �6   �� 5      $��44 �6   �� 5      .+�5   
   �� -   5        $��testBox��5      $��2��6    $��3��6-   $	��385��5   E   $��Bottom=�6R   $��4��6�   $	��921��6�   o� 5    
    o� 
IsMainMenu . $��6��6!   .@�5!      m� $��_File��6   .@�5"      m� $
��_New��6   �� 5#      m� 5$      $��_Open��6   �� 5%      m� 5&      $��_Save��6   m� 5'      $��_Save As��6   �� 5(      m� 5)      $��_Print��6   5*      m� 5+      $��_Edit��6   .@�5,      m� $��_Undo��6   �� 5-      m� 5.      $
��_Cut��6   m� 5/      $��_Copy��6   m� 50      $��_Paste��6   51      m� 52      $��_View��6   .@�53      m� $��_Screen Mode��6   54      m� 55      $��_Window��6   m� 56      $��_Help��6   .@�57      m� $��About��6   59      5:      d� 5=   
   -   5        $��
grabButton��5=      $��4��5>   4   $��1��6A   $
��Grab��6Q   d� 5?   
   -   5        $��zoomInButton��5?      $��3��5@   6   $��1��6C   d� 5A   
   -   5        $��zoomOutButton��5A      $��1��5B   7   $��2��6G    J� RenderTransformOrigin$ 0.5,0.5&�6T   5C      �� 5D   
   -   5        $��zoomLbl��5D      $��	Zoom: x 1��5E      $ 0.504,0.526&�6$   $��3��6H   $��2��6Y   $��759,16,23,0q�6j   $��3��6   5H      5J      