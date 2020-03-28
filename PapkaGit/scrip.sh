#!/bin/bash
git clone $1
cd testrepo
csc $2.cs
mono $2.exe