import { Camera, CameraType } from 'expo-camera';
import { useState, useEffect } from 'react';
import { Button, StyleSheet, Text, TouchableOpacity, View, Alert } from 'react-native';

export default function App() {
  const [type, setType] = useState(CameraType.back);
  const [permission, requestPermission] = Camera.useCameraPermissions();
  const [scanned, setScanned] = useState(false); // To manage scanning state

  useEffect(() => {
    (async () => {
      const { status } = permission;
      if (status !== 'granted') {
        Alert.alert('Permission Denied', 'Sorry, we need camera permissions to make this work!');
      }
    })();
  }, []);

  // Function to handle barcode scans
  const handleBarCodeScanned = ({ type, data }) => {
    setScanned(true); // Prevent further scans until reset
    Alert.alert("QR Code Scanned", `Type: ${type}\nData: ${data}`, [
      { text: "OK", onPress: () => setScanned(false) } // Reset scanning state
    ]);
  };

  if (!permission) {
    return <View style={styles.container}><Text>Requesting permission</Text></View>;
  }

  if (permission.status === 'denied') {
    return (
      <View style={styles.container}>
        <Text>No access to camera</Text>
        <Button title={'Request Permission'} onPress={() => requestPermission()} />
      </View>
    );
  }

  if (permission.status === 'granted') {
    return (
      <View style={styles.container}>
        <Camera
          style={styles.camera}
          type={type}
          onBarCodeScanned={scanned ? undefined : handleBarCodeScanned} 
        >
          <View style={styles.buttonContainer}>
    
              <View style = {styles.container}>
              <Text style={styles.text}>Scanati Codul QR pentru a inregistra primire comenzii</Text>
          </View>
          </View>
        </Camera>
      </View>
    );
  }


  return <View style={styles.container}><Text>Requesting permission</Text></View>;
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
  },
  camera: {
    flex: 1,
    width: '100%', // Ensure the camera fills the width of the screen
  },
  buttonContainer: {
    flex: 1,
    backgroundColor: 'transparent',
    flexDirection: 'row',
  },
  button: {
    flex: 0.1,
    alignSelf: 'flex-end',
    alignItems: 'center',
  },
  text: {
    fontSize: 18,
    marginBottom: 10,
    color: 'white',
  },
});
