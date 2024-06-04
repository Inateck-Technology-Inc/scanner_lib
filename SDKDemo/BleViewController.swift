//
//  BleViewController.swift
//  SDKDemo
//
//  Created by inateck on 2024/5/20.
//

import UIKit
import InateckScannerBleKit

class BleViewController: UIViewController {
    
    var device: BLEDevice?
    
    @IBOutlet weak var tableView: UITableView!
    var settings = [
        "version",
        "battery",
        "software",
        "settingInfo",
        "closeVolume",
        "openVolume"
    ]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.dataSource = self
        tableView.delegate = self
        tableView.rowHeight = 50
        tableView.register(UITableViewCell.self, forCellReuseIdentifier: "UITableViewCell")
        
        BLEManager.shared.disconnectHandler = { device in
            if self.device?.uuid == device.uuid {
                self.navigationController?.popViewController(animated: true)
            }
        }
    }

}

extension BleViewController: UITableViewDataSource {
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        settings.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let item = settings[indexPath.row]
        let cell = tableView.dequeueReusableCell(withIdentifier: "UITableViewCell", for: indexPath)
        cell.textLabel?.text = item
        cell.accessoryType = .detailButton
        return cell
    }
}

extension BleViewController: UITableViewDelegate {
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        tableView.deselectRow(at: indexPath, animated: false)
        switch indexPath.row {
        case 0:
            device?.messageManager.getHardwareInfo({ result in
                switch result {
                case .success(let version):
                    print("version: \(version)")
                case .failure(let failure):
                    print("version failed: \(failure)")
                }
            })
        case 1:
            device?.messageManager.getBatteryInfo({ result in
                switch result {
                case .success(let battery):
                    print("battery: \(battery)")
                case .failure(let failure):
                    print("battery failed: \(failure)")
                }
            })
        case 2:
            device?.messageManager.getVersion({ result in
                switch result {
                case .success(let version):
                    print("software: \(version)")
                case .failure(let failure):
                    print("software failed: \(failure)")
                }
            })
        case 3:
            device?.messageManager.getSettingInfo({ result in
                switch result {
                case .success(let info):
                    print("info: \(info)")
                case .failure(let failure):
                    print("info failed: \(failure)")
                }
            })
        case 4:
            let closeVolume = "[{\"area\":\"3\",\"value\":\"0\",\"name\":\"volume\"}]"
            device?.messageManager.setSettingInfo(with: closeVolume, completion: { result in
                switch result {
                case .success:
                    print("close volume success")
                case .failure(let failure):
                    print("close volume failed: \(failure)")
                }
            })
        case 5:
            let openVolume = "[{\"area\":\"3\",\"value\":\"4\",\"name\":\"volume\"}]"
            device?.messageManager.setSettingInfo(with: openVolume, completion: { result in
                switch result {
                case .success:
                    print("open volume success")
                case .failure(let failure):
                    print("open volume failed: \(failure)")
                }
            })
        default:
            break
        }
    }
}
