<?php
$link =  mysqli_connect("localhost", "root", "","registernew");

$username = $_REQUEST['username']; 
$password = $_REQUEST['password']; 

//mysqli_connect($link) or die(mysqli_connect_error()); 
//$db_selected = mysqli_select_db("registernew", $link);

$check = mysqli_query($link, "SELECT * FROM `register_new_user` WHERE `username`='".$username."'" ) or die (mysqli_connect_error());
$numrows = mysqli_num_rows($check);
if ($numrows == 0)
	die("Username doesn't exist \n");
else {
	
	while ($row = mysqli_fetch_assoc($check)) {//finds the rows that have our username
		if($password == $row['password'])
			die("login-SUCCESS".$row['id']);
		else
			die("Password doesn't match \n");
	}
}
?>