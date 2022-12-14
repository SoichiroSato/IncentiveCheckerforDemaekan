#!/bin/bash
google=`google-chrome -version`
if [ $? -eq 127 ]; then
  os=`cat /etc/os-release`
  echo $os
  if [[ "$os" == *CentOS* ]] || [[ "$os" == *centos* ]]; then
    sudo yum install https://dl.google.com/linux/direct/google-chrome-stable_current_x86_64.rpm
    sudo yum install google-chrome-stable
  elif [[ "$os" == *ubuntu* ]]; then
    sudo apt update
    sudo apt upgrade
    sudo wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
    sudo apt install ./google-chrome-stable_current_amd64.deb
    sudo apt -f install
    sudo rm google-chrome-stable_current_amd64.deb*
  fi
else
  echo $google
fi
