# Memory Puzzle Prototype — Technical Design Document

## Project

Echoes of the Library

## Prototype Target

Level 2 — Lorong Halaman Hilang

---

# Objective

Membuat prototype gameplay memory puzzle sederhana yang:

* scalable
* modular
* mudah diintegrasikan ke Visual Novel
* mudah di-replace menggunakan asset final

Prototype fokus pada validasi mechanic gameplay terlebih dahulu, bukan visual polish.

---

# Gameplay Overview

Player harus mencocokkan pasangan kartu memory untuk memulihkan halaman cerita yang hilang.

Gameplay flow:

```plaintext
Explore Area
↓
Dialogue VN
↓
Memory Puzzle Triggered
↓
Player Match All Cards
↓
Story Continues
```

---

# Core Mechanics

## Basic Rules

* Player hanya bisa membuka 2 kartu sekaligus.
* Jika pair cocok:

  * kartu tetap terbuka.
* Jika pair tidak cocok:

  * kartu tertutup kembali setelah delay.
* Semua pair harus ditemukan untuk menyelesaikan puzzle.

---

# Prototype Scope

## Initial Grid

Gunakan:

* 2x2
  atau
* 4x2

Jangan langsung menggunakan grid besar.

---

# Unity Scene Structure

```plaintext
Scenes/
└── Puzzle/
    └── MemoryPuzzle_Test.unity
```

---

# Recommended Hierarchy

```plaintext
MemoryPuzzleScene
│
├── Main Camera
│
├── EventSystem
│
├── MemoryPuzzleManager
│   ├── AudioSource
│   └── MemoryGameManager.cs
│
├── Canvas
│   │
│   ├── Background
│   │
│   ├── TopUI
│   │   ├── TitleText
│   │   └── MovesText
│   │
│   ├── CardGrid
│   │   └── Grid Layout Group
│   │
│   ├── WinPanel
│   │   ├── WinText
│   │   └── RestartButton
│   │
│   └── RetryPanel
│       ├── RetryText
│       └── RetryButton
```

---

# Folder Structure

```plaintext
Assets/
└── _Project/
    ├── Prefabs/
    │   └── Puzzle/
    │       └── MemoryCard.prefab
    │
    ├── Scenes/
    │   └── Puzzle/
    │       └── MemoryPuzzle_Test.unity
    │
    ├── Scripts/
    │   └── Puzzle/
    │       └── Memory/
    │           ├── MemoryCard.cs
    │           ├── MemoryGameManager.cs
    │           ├── CardData.cs
    │           └── ShuffleSystem.cs
    │
    └── Art/
        └── UI/
            └── MemoryCards/
```

---

# Card Prefab Structure

```plaintext
MemoryCard
│
├── CardVisual
│   ├── CardBack
│   └── CardFront
│
└── Button
```

---

# Card Components

## Root Object

Components:

* RectTransform
* Button
* MemoryCard.cs

---

## CardBack

Type:

* UI Image

Function:

* tampilan belakang kartu

---

## CardFront

Type:

* UI Image

Function:

* tampilan isi kartu

Prototype placeholder:

* huruf
* angka
* icon sederhana

Default state:

* hidden

---

# Flip System

Prototype menggunakan sistem sederhana:

Open card:

```csharp
cardBack.SetActive(false);
cardFront.SetActive(true);
```

Close card:

```csharp
cardBack.SetActive(true);
cardFront.SetActive(false);
```

---

# Matching System

Gunakan:

```csharp
public int cardID;
```

Check:

```csharp
if(cardA.cardID == cardB.cardID)
{
    // match
}
```

---

# Grid Layout Settings

Object:

* CardGrid

Component:

* Grid Layout Group

Recommended settings:

```plaintext
Cell Size:
150 x 200

Spacing:
20 x 20

Constraint:
Fixed Column Count

Column Count:
4
```

---

# GameManager Responsibilities

## MemoryGameManager.cs

Responsibilities:

* spawn card
* shuffle card
* track selected cards
* compare pair
* track matched count
* trigger win state

---

# Prototype Placeholder Assets

Temporary assets:

* colored cards
* alphabet icons
* simple symbols

Do NOT use final assets yet.

---

# Win Condition

Puzzle selesai jika:

* semua pair berhasil ditemukan

Action:

* tampilkan WinPanel
* trigger next VN scene

---

# Future Scalability

Prototype architecture harus mendukung:

* replace sprite asset
* larger grid
* VN integration
* sound effect
* animation
* finalMemory system

---

# Future Improvements

## Visual Polish

* flip animation
* particle effect
* cozy fantasy UI
* shadow ink effect

## Gameplay Expansion

* fake cards
* timer system
* moving cards
* corrupted cards

---

# Final Goal

Prototype harus:

* fully playable
* stable
* modular
* scalable
* siap diintegrasikan ke gameplay VN utama
