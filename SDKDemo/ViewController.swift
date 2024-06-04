//
//  ViewController.swift
//  SDKDemo
//
//  Created by inateck on 2024/5/20.
//

import UIKit
import InateckScannerBleKit

class ViewController: UIViewController {
    
    @IBOutlet weak var tableView: UITableView!

    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.dataSource = self
        tableView.delegate = self
        tableView.rowHeight = 80
        tableView.register(.init(nibName: "BleTableViewCell", bundle: nil), forCellReuseIdentifier: "BleTableViewCell")
        
        navigationItem.rightBarButtonItem = UIBarButtonItem(title: "Scan",
                                                            style: .plain,
                                                            target: self,
                                                            action: #selector(onScan))
        navigationItem.leftBarButtonItem = UIBarButtonItem(title: "Stop",
                                                           style: .plain,
                                                           target: self,
                                                           action: #selector(onStop))
        
        scanDevices()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)
        tableView.reloadData()
    }
    
    @objc func onScan() {
        scanDevices()
    }
    
    @objc func onStop() {
        BLEManager.shared.stopScan()
    }
    
    func scanDevices() {
        let manager = BLEManager.shared
        let activity = UIActivityIndicatorView(style: .medium)
        activity.startAnimating()
        navigationItem.rightBarButtonItem = UIBarButtonItem(customView: activity)
        manager.scanDevices(timeoutAfter: 5) { state in
            switch state {
            case .start:
                self.tableView.reloadData()
            case .scan(_):
                self.tableView.reloadData()
            case .stop:
                self.tableView.reloadData()
                self.navigationItem.rightBarButtonItem = UIBarButtonItem(title: "Scan",
                                                                    style: .plain,
                                                                    target: self,
                                                                         action: #selector(self.onScan))
            @unknown default:
                self.tableView.reloadData()
            }
        }
    }

}

extension ViewController: UITableViewDataSource {
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        BLEManager.shared.devices.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "BleTableViewCell", for: indexPath) as! BleTableViewCell
        let device = BLEManager.shared.devices[indexPath.row]
        cell.nameLbl.text = device.name
        cell.uuidLabel.text = device.uuid
        cell.connectSwitch.isHidden = false
        cell.loadingView.isHidden = false
        switch device.connectState {
        case .connected:
            cell.connectSwitch.isOn = true
            cell.loadingView.isHidden = true
        case .connecting:
            cell.connectSwitch.isHidden = true
            cell.loadingView.isHidden = false
        case .disconnected:
            cell.connectSwitch.isOn = false
            cell.loadingView.isHidden = true
        case .disconnecting:
            cell.connectSwitch.isHidden = true
            cell.loadingView.isHidden = false
        case .none:
            break
        @unknown default:
            break
        }
        cell.connectHandler = { connect in
            if connect {
                device.connect(timeout: 5) { result in
                    switch result {
                    case .success:
                        print("\(device.name ?? "unknown") connect success")
                    case .failure(let failure):
                        print("\(device.name ?? "unknown") connect failure: \(failure)")
                    }
                    tableView.reloadData()
                }
            } else {
                device.disconnect { result in
                    switch result {
                    case .success:
                        print("\(device.name ?? "unknown") disconnect success")
                    case .failure(let failure):
                        print("\(device.name ?? "unknown") disconnect failure: \(failure)")
                    }
                    tableView.reloadData()
                }
            }
        }
        return cell
    }
    
}

extension ViewController: UITableViewDelegate {
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let device = BLEManager.shared.devices[indexPath.row]
        let bleVc = BleViewController()
        bleVc.device = device
        self.navigationController?.pushViewController(bleVc, animated: true)
    }
}

