//
//  BleTableViewCell.swift
//  SDKDemo
//
//  Created by inateck on 2024/5/20.
//

import UIKit

class BleTableViewCell: UITableViewCell {

    @IBOutlet weak var nameLbl: UILabel!
    @IBOutlet weak var uuidLabel: UILabel!
    @IBOutlet weak var connectSwitch: UISwitch!
    @IBOutlet weak var loadingView: UIActivityIndicatorView!
    
    var connectHandler: ((Bool) -> ())?
    
    override func awakeFromNib() {
        super.awakeFromNib()
        connectSwitch.isOn = false
    }
    
    @IBAction func onClickConnect(_ sender: UISwitch) {
        connectHandler?(sender.isOn)
    }
    
}
