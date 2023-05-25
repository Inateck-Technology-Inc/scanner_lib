//
//  ViewController.swift
//  ios_sdk
//
//  Created by inateck on 2023/4/19.
//  Copyright © 2023 inateck. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

    @IBAction func onClickBle(_ sender: UIButton) {
        let device = scanDevice();
        print("device ---- \(device)")
        let connect = connectDevice(deviceId:"d0000", appId: "***", developerId: "***", appKey: "***")
        print("connect ---- \(connect)")
    }
    
}

