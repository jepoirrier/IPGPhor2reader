# IPGPhor 2 Reader, a tool to read IPGPhor 2 log files and plot graphs

## Introduction

IPGPhor is a device from GE Healthcare (formerly Amersham Biosciences) that performs an isoelectrofocusing of proteins. Version 2 of IPGPhor can be connected to any computer via a serial cable. GE Healthcare provides a monitoring software but no post-hoc analysis software. This gap is efficiently filled by IPGPhor 2 Reader.

The goal of IPGPhor 2 Reader is to parse log (text) files resulting from an experiment with the IPGPhor and to plot graphs.

## Features:

* Works with IPGPhor version 2 (not tested with version 3 but it should also work) ; please note that the software checks that the first line states "Amersham Biosciences" (you can check that with Notepad if you like)
* Displays a plot of voltage (V), "amperage" (µA) and total voltage (Vhrs)
* Easily puts the graph into the clipboard and/or saves it in many common graphics formats
* Object-oriented design and open-source

## Software

The project was hosted on Sourceforge.net and, since 2016, is hosted on Github. You can choose the executable (in bin/), source code (in src/) and some data samples (in sampledata/) if you want to test the software.

The link above gives an archive that includes the executable (the software you'll use). You can run this software under MS-Windows, provided you have the .Net framework. If you regularly update your computer, you should already have it. Anyway, you can download it from Microsoft and install it.

This software is released under the GNU General Public Licence (GPL).

Copyright (C) belongs to Jean-Etienne Poirrier, 2006-2015. You can contact me at jepoirrier at gmail.com. Please report if you have any problem, comment or if you would like new features in this software.

## Usage

The software is so simple that there should be no problem to use it ... When you launch it, open a log file from IPGPhor and it will give you the results.

To copy or save the plot, just right-clic on it. With this contextual menu, you'll also be able to print it, to zoom/un-zoom and to show point values.
