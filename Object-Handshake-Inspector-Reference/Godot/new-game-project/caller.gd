extends Node3D

@export var receiver: Node

func _ready() -> void:
	print("Hello Friend")
	receiver.OnCalled()
