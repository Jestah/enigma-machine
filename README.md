# Enigma Machine 

This is a simple enigma machine project to learn more about C# and the mechanisms of an enigma machine alike.

## Description

By default there are 3 rotors in the machine with all 26 characters of the english alphabet. The rotor roll-over positions (the position at which the first rotor turns the second rotor once every cycle) are not on the last positions. This is to better emulate the original enigma machine rotors.

This enigma machine also supports the counterintuitive behaviour known as "double stepping". For a visual demonstration check out [this great video](https://www.youtube.com/watch?v=hcVhQeZ5gI4) by @ledermueller.

A typical enigma machine has 5 discs. The Eintrittswalze (ETW) which is the first character mapping disc that the encryption goes through, then 3 rotatable and hot-swappable discs known as rotors which change position after each encrypted character, and lastly the Umkehrwalze (UKW) which reflects the encryption signal back through the previous discs.

The initial rotor mapping as created in the CLI main method is intended to imitate the default rotor setup of the Enigma-G model although there may be some character mapping inaccuracies.

## Getting Started

[//]: # (### Installing)

### Executing program

To start the program navigate to `~\Enigma\EnigmaCLI` then run `dotnet run'

## Available Commands

The following commands are available in the EnigmaCLI:

### Exit

```csharp
exit
```

- exit the program.

### Encrypt

```
encrypt {INPUT STRING}

// Example input (assuming rotor positions at 0 0 0)
encrypt abc

// Example output
The encrypted string is: hoo
************
* 00 00 03 *
************
```

- Encrypts the provided input string using the Enigma machine and prints the encrypted string along with the new rotor positions.

### Decrypt

```
decrypt {INPUT STRING}

// Example input (assuming rotor positions at 0 0 0)
decrypt hoo

// Example output
The decrypted string is: abc
************
* 00 00 03 *
************
```

- Decrypts the provided input string using the Enigma machine and prints the decrypted string along with the new rotor positions.

### Set Rotor Positions

```
setpositions {DESIRED ROTOR POSITIONS};

// Example input
setpositions  0 13 7

// Example output
Rotor positions updated. The new positions are:
************
* 00 13 07 *
************
```

- Sets the positions of the rotors based on the provided array of positions.
- By default there are 3 rotors with 25 steps each (all 26 letters in the english alphabet)

## License

This project is licensed under the MIT License - see the LICENSE.md file for details