   M S B A M L   `   `   `  ����J  FMultiSerialPort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MultiSerialPortMultiSerialPort  5   	        MultiSerialPort.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MultiSerialPort     5   	   
�������  � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��30 �6   6*   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $��20 �6   6,   �� 5      $
��Auto �6   6.   .+�5   
   �  5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��port 1 received data :��6   6;   �� 5      -   5        $��
PortLabel1��5      $��80��6*   67   5      �� 5      $ 
Horizontal=�6   $��1��62   .+�5      �� $��port 3 received data :��6   6;   �� 5       -   5        $��
PortLabel3��5       $��80��6*   67   5!      �� 5"      $ 
Horizontal=�6   $��2��62   .+�5#      �� $��port 5 received data :��6   6;   �� 5$      -   5        $��
PortLabel5��5$      $��80��6*   67   5%      5&      �� 5'   
   -   5        $��1��5'      $��0��6   $��
start test��6.   $��	10,0,10,0q�6C   5(   (   � 5)   
   $��0��6   $��2��6    5*      �� 5+      $
��Auto �6    60   �� 5,      $
��Auto �6    60   �� 5-      $
��Auto �6    60   .+�5/      �� $ 
Horizontal=�6   .+�50      �� $��port 7 received data :��6   6;   �� 51      -   5        $��
PortLabel7��51      $��80��6*   67   52      �� 53      $ 
Horizontal=�6   $��1��62   .+�54      �� $��port 9 received data :��6   6;   �� 55      -   5        $��
PortLabel9��55      $��80��6*   67   56      57      58      59      