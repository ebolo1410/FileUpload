<?php
$target_dir = "uploads/";

$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);

$uploadOk = 1;

$fileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));

if (file_exists($target_file)){
    echo "File exists!!!";
    $uploadOk = 0;
}

if ($_FILES["fileToUpload"]["size"] > 500000){
    echo "File too large!!!";
    $uploadOk = 0;
}

$allowedType = array("jpg","jpeg","png","gif");

if(!in_array($fileType,$allowedType)){
    echo "Wrong file type!!!";
    $uploadOk = 0;
}

if ($uploadOk == 0){
    echo "Not uploaded!!";
}
else{
    if(move_uploaded_file($_FILES["fileToUpload"]["tmp_name"],$target_file)){
        echo "The file" . htmlspecialchars(basename($_FILES["fileToUpload"]["name"])) . " has been uploaded";
    }
    else{
        echo "Error!!";
    }
}

?>